using UnityEngine;
using System.Collections;

public static class UvProjector
{
	public static void ProjectUvs(Transform[] targets, Transform viewpoint, Camera camera)
	{
		ProjectUvs(targets, viewpoint.position, viewpoint.rotation, camera);	
	}
	
	public static void ProjectUvs(Transform[] targets, Vector3 position, Quaternion rotation, Camera camera)
	{
		Matrix4x4 viewMatrix = new Matrix4x4();
		
		viewMatrix.SetTRS(position, rotation, Vector3.one );
		
		Matrix4x4 projection = camera.projectionMatrix;
		
		Matrix4x4 projectionViewMatrix = projection * viewMatrix.inverse;
		
		foreach(Transform target in targets)
		{
			Matrix4x4 projectionViewModelMatrix = projectionViewMatrix * target.localToWorldMatrix;
			
			MeshFilter meshFilter = target.GetComponent<MeshFilter>();
			Mesh mesh = meshFilter.mesh;
			Vector2[] uvs = new Vector2[mesh.uv.Length];
			Vector3[] vertices = mesh.vertices;
			
			for(int i = 0 ; i < uvs.Length ; i++)
			{
				Vector3 vertex =  vertices[i];
				Vector4 homogonousVertex =  new Vector4(vertex.x, vertex.y, vertex.z, 1f);
				homogonousVertex = target.localToWorldMatrix * homogonousVertex;
				homogonousVertex = viewMatrix.inverse * homogonousVertex;
				
				homogonousVertex = projection * homogonousVertex;
				
				homogonousVertex *= 1 / -homogonousVertex.z;
				
				Vector3 uv = homogonousVertex;
				uvs[i] = ReMap(new Vector2(uv.x, uv.y));
			}
			
			mesh.uv = uvs;
		}
	}
	
	private static Vector2 ReMap(Vector2 uvs)
	{		
		
		uvs += Vector2.one;
		uvs /= 2f;
		
		
		return uvs;
		
	}
	
}
