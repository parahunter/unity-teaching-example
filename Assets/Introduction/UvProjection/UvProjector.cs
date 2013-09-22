using UnityEngine;
using System.Collections;

public static class UvProjector
{
	public static void ProjectUvs(Transform[] targets, Transform viewpoint, Matrix4x4 viewMatrix)
	{
		ProjectUvs(targets, viewpoint.position, viewpoint.rotation, viewMatrix);	
	}
	
	public static void ProjectUvs(Transform[] targets, Vector3 position, Quaternion rotation, Matrix4x4 projectionMatrix)
	{
		
		Matrix4x4 viewMatrix = new Matrix4x4();
		viewMatrix.SetTRS(position, rotation, Vector3.one);
				
		Matrix4x4 projectionViewMatrix = projectionMatrix * viewMatrix.inverse;
		
		foreach(Transform target in targets)
		{
			Matrix4x4 projectionViewModelMatrix = projectionViewMatrix * target.localToWorldMatrix;
			
			MeshFilter meshFilter = target.GetComponent<MeshFilter>();
			
			Mesh mesh = meshFilter.mesh;
			Vector2[] uvs = new Vector2[mesh.uv.Length];
			Vector3[] vertices = mesh.vertices;
			
			for(int i = 0 ; i < uvs.Length ; i++)
			{
				Vector3 vertex = vertices[i];
				Vector2 uv = projectionMatrix * vertex;
				uvs[i] = uv;
			}
			
			mesh.uv = uvs;
		}
	}
	
}
