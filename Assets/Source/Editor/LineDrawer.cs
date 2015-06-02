using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

public static class LineDrawer
{

	#region Materials

	private static Material customWireMaterial;
	private static Material CustomWireMaterial
	{
		get
		{
			if (customWireMaterial == null)
			{
				customWireMaterial = (Material)Resources.Load("customWireMaterial", typeof(Material));
			}
			return customWireMaterial;
		}
	}

	private static Material customWireDottedMaterial;
	private static Material CustomWireDottedMaterial
	{
		get
		{
			if (customWireDottedMaterial == null)
			{
				customWireDottedMaterial = (Material)Resources.Load("customWireDottedMaterial", typeof(Material));
			}
			return customWireDottedMaterial;
		}
	}

	#endregion

	public static void DrawLine(Vector3 from, Vector3 to, Color c)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}
		
		if (CustomWireMaterial.SetPass(0))
		{
			GL.Begin(GL.LINES);
			GL.Color(c);
			GL.Vertex(from);
			GL.Vertex(to);
			GL.End();
		}
	}

	public static void DrawLines(Vector3[] lines, Color c)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if ((lines.Length & 1) == 1)
		{
			Debug.LogWarning("Uneven number of vertices in line array!");
		}
			
		if (CustomWireMaterial.SetPass(0))
		{
			GL.Begin(GL.LINES);
			GL.Color(c);
			for (int i = 0; i < lines.Length; i += 2)
			{
				var pt0 = lines[i + 0];
				var pt1 = lines[i + 1];
				GL.Vertex(pt0);
				GL.Vertex(pt1);
			}
			GL.End();
		}
	}

    public static void DrawLine(Matrix4x4 matrix, Vector3 from, Vector3 to, Color c)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if (CustomWireMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			GL.Vertex(from);
			GL.Vertex(to);
			GL.End();
			GL.PopMatrix();
		}
	}

    public static void DrawLines(Matrix4x4 matrix, Vector3[] lines, Color c)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if ((lines.Length & 1) == 1)
		{
			Debug.LogWarning("Uneven number of vertices in line array!");
		}
			

		if (CustomWireMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			for (int i = 0; i < lines.Length; i += 2)
			{
				var pt0 = lines[i + 0];
				var pt1 = lines[i + 1];
				GL.Vertex(pt0);
				GL.Vertex(pt1);
			}
			GL.End();
			GL.PopMatrix();
		}
	}
	public static void DrawDottedLine(Vector3 from, Vector3 to, Color c, float dotSize = 4.0f)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}
		if (CustomWireDottedMaterial.SetPass(0))
		{
			GL.Begin(GL.LINES);
			GL.Color(c);
			GL.MultiTexCoord(0,   to); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(from);
			GL.MultiTexCoord(0, from); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(to);
			GL.End();
		}
		CustomWireMaterial.SetPass(0);
    }

	public static void DrawDottedLines(Vector3[] lines, Color c, float dotSize = 4.0f)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if ((lines.Length & 1) == 1)
		{
			Debug.LogWarning("Uneven number of vertices in line array!");
		}

		if (CustomWireDottedMaterial.SetPass(0))
		{
			GL.Begin(GL.LINES);
			GL.Color(c);
			for (int i = 0; i < lines.Length; i += 2)
			{
				var pt0 = lines[i + 0];
				var pt1 = lines[i + 1];
				GL.MultiTexCoord(0, pt1); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt0);
				GL.MultiTexCoord(0, pt0); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt1);
			}
			GL.End();
		}
		CustomWireMaterial.SetPass(0);
    }

	public static void DrawDottedLine(Matrix4x4 matrix, Vector3 from, Vector3 to, Color c, float dotSize = 4.0f)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if (CustomWireDottedMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			GL.MultiTexCoord(0,   to); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(from);
			GL.MultiTexCoord(0, from); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(to);
			GL.End();
			GL.PopMatrix();
		}
	}

	public static void DrawDottedLines(Matrix4x4 matrix, Vector3[] lines, Color c, float dotSize = 4.0f)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if ((lines.Length & 1) == 1)
		{
			Debug.LogWarning("Uneven number of vertices in line array!");
		}
			
		if (CustomWireDottedMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			for (int i = 0; i < lines.Length; i += 2)
			{
				var pt0 = lines[i + 0];
				var pt1 = lines[i + 1];
				GL.MultiTexCoord(0, pt1); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt0);
				GL.MultiTexCoord(0, pt0); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt1);
			}
			GL.End();
			GL.PopMatrix();
		}
	}

	public static void DrawLines(Matrix4x4 matrix, Vector3[] vertices, Int32[] indices, int lineCount, Color c)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if (lineCount == 0)
		{
			return;
		}

		if (indices.Length < lineCount * 2)
		{
			Debug.LogWarning("indices.Length < lineCount * 2");
			return;
		}

		if (CustomWireMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			var indexCount = lineCount * 2;
			for (int i = 0; i < indexCount; i += 2)
			{
				var pt0 = vertices[indices[i + 0]];
				var pt1 = vertices[indices[i + 1]];
				GL.Vertex(pt0);
				GL.Vertex(pt1);
			}
			GL.End();
			GL.PopMatrix();
		}
	}

	public static void DrawDottedLines(Matrix4x4 matrix, Vector3[] vertices, Int32[] indices, int lineCount, Color c, float dotSize = 4.0f)
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}

		if (lineCount == 0)
		{
			return;
		}

		if (indices.Length < lineCount * 2)
		{
			Debug.LogWarning("indices.Length < lineCount * 2");
			return;
		}
			
		if (CustomWireDottedMaterial.SetPass(0))
		{
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			GL.Begin(GL.LINES);
			GL.Color(c);
			var indexCount = lineCount * 2;
            for (int i = 0; i < indexCount; i += 2)
			{
				var pt0 = vertices[indices[i + 0]];
				var pt1 = vertices[indices[i + 1]];
				GL.MultiTexCoord(0, pt1); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt0);
				GL.MultiTexCoord(0, pt0); GL.MultiTexCoord2(1, dotSize, 0); GL.Vertex(pt1);
			}
			GL.End();
			GL.PopMatrix();
		}
	}
}
