using UnityEngine;
using UnityEditor;
[InitializeOnLoad]
public sealed class UnitySceneEventHandler
{

    static UnitySceneEventHandler   editor;
    static UnitySceneEventHandler()
	{
		SceneView.onSceneGUIDelegate += OnScene;
	}

    
	static void OnScene(SceneView sceneView)
    {
        var current = Event.current;
		switch(current.type)
		{
			case EventType.DragPerform:
			{ 
				break;
			}
			case EventType.DragUpdated:
			{ 
				break;
			}
			case EventType.DragExited:
			{ 
				break;
			}
			case EventType.MouseMove:
			{ 
				break;
			}
			case EventType.MouseDown:
			{ 
				break;
			}
			case EventType.MouseUp:
			{ 
				break;
			}
			case EventType.Repaint:
			{
				Vector3 delta = new Vector3(0,0,10.0f);
                LineDrawer.DrawLine(Matrix4x4.identity, Vector3.zero, delta, new Color(1,1,1,0.75f));

				for (int i = 2; i < 20; i++)
				{
					var pos = new Vector3(i, 0, 0);
                    LineDrawer.DrawDottedLine(Matrix4x4.identity, pos, pos + delta, new Color(1, 1, 1, 0.75f), i);
				}
                break;
			}	
			case EventType.Layout:
			{ 
				break;
			}
			default:
			{ 
				break;
			}
		}
	}
}