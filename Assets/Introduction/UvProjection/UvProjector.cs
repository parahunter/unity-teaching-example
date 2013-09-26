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
		Debug.Log(projection);
		Debug.Log("view " + viewMatrix);
		
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
				Debug.Log("Vertex " + homogonousVertex);
				homogonousVertex = target.localToWorldMatrix * homogonousVertex;
				Debug.Log("in global space " + homogonousVertex);
				homogonousVertex = viewMatrix.inverse * homogonousVertex;
				Debug.Log("in camera space " + homogonousVertex);
				
				homogonousVertex = projection * homogonousVertex;
				Debug.Log("in normalized space " + homogonousVertex);
				
				homogonousVertex *= 1 / -homogonousVertex.z;
				
				Vector3 uv = homogonousVertex;
				Debug.Log("uv " + uv);
				uvs[i] = ReMap(new Vector2(uv.x, uv.y));
			}
			
			mesh.uv = uvs;
		}
	}
	
	private static Vector2 ReMap(Vector2 uvs)
	{		
//		uvs.x = 0.5f * uvs.x ;
//		uvs.y = 0.5f * uvs.y ;		
		
		uvs += Vector2.one;
		uvs /= 2f;
		
		
		return uvs;
		
	}
	
}
