using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Math.Core;
using Fusee.Serialization;

namespace FuseeApp
{
    public class CuboidMesh : Mesh
    {
        public CuboidMesh(float3 size)
        {
            Vertices = new MeshAttributes<float3>(new float3[]
            {
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z}
            });

            Triangles = new MeshAttributes<uint>(new uint[]
            {
                // front face
                0, 2, 1, 0, 3, 2,
                // right face
                4, 6, 5, 4, 7, 6,
                // back face
                8, 10, 9, 8, 11, 10,
                // left face
                12, 14, 13, 12, 15, 14,
                // top face
                16, 18, 17, 16, 19, 18,
                // bottom face
                20, 22, 21, 20, 23, 22
            });

            Normals = new MeshAttributes<float3>(new float3[]
            {
                new float3(0, 0, 1),
                new float3(0, 0, 1),
                new float3(0, 0, 1),
                new float3(0, 0, 1),
                new float3(1, 0, 0),
                new float3(1, 0, 0),
                new float3(1, 0, 0),
                new float3(1, 0, 0),
                new float3(0, 0, -1),
                new float3(0, 0, -1),
                new float3(0, 0, -1),
                new float3(0, 0, -1),
                new float3(-1, 0, 0),
                new float3(-1, 0, 0),
                new float3(-1, 0, 0),
                new float3(-1, 0, 0),
                new float3(0, 1, 0),
                new float3(0, 1, 0),
                new float3(0, 1, 0),
                new float3(0, 1, 0),
                new float3(0, -1, 0),
                new float3(0, -1, 0),
                new float3(0, -1, 0),
                new float3(0, -1, 0)
            });

            UVs = new MeshAttributes<float2>(new float2[]
            {
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0),
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0),
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0),
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0),
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0),
                new float2(1, 0),
                new float2(1, 1),
                new float2(0, 1),
                new float2(0, 0)
            });
        }
    }

    public class CylinderMesh : Mesh
    {
        public CylinderMesh(float radius, float height, int segments) 
        { 
            // Speicherplätze für Vertices, Normals und Trainagles reservieren
            float3[] verts = new float3[4 * segments + 2];
            float3[] norms = new float3[4 * segments + 2];
            uint[] tris = new uint[4 * 3 * segments];

            // Punkt auf der x - Achse als ersten Punkt in den Array
            verts[0] = new float3(radius, 0, 0);
            norms[0] = new float3(0, 1, 0);
            
            // Punkt in der Mitte des Kreises als letzten Punkt in den Array 
            verts[segments] = new float3(0, 0, 0);
            norms[segments] = new float3(0, 1, 0);

            float delta = 2 * M.Pi / segments;

            for(int i = 1; i < segments; i++)
            {
                // Ein neuer Punkt auf Kreisfläche hinzufügen
                verts[i] = new float3(radius * (float) Math.Cos(i * delta), 0, radius * (float) Math.Sin(i * delta));
                norms[i] = new float3(0, 1, 0);

                // Mantel vom Zylinder
                verts[i] = new float3((float) Math.Cos(i * delta), 0, (float) Math.Sin(i* delta));
                norms[i] = new float3((float) Math.Cos(i * delta), 0, (float) Math.Sin(i* delta));

                // Dreieck oben
                tris[12 * (i - 1)] = (uint) (4 * segments);           // Mittelpunkt oben
                tris[12 * (i - 1) + 1] = (uint) (4 * i);              // aktueller obiger Segmentpunkt
                tris[12 * (i - 1) + 2] = (uint) (4 * (i - 1));        // vorheriger Segmentpunkt oben
                // seitlicher Dreieck 1
                tris[12 * (i - 1) + 3] = (uint) (4 * (i - 1) + 2);        // vorheriger tiefer Punkt 
                tris[12 * (i - 1) + 4] = (uint) (4 * i + 2);              // aktueller tiefer Punkt
                tris[12 * (i - 1) + 5] = (uint) (4 * i + 1);              // vorheriger obiger Punkt

                // seitliches Dreieck 2
                tris[12 * (i - 1) + 6] = (uint) (4 * (i - 1) + 2);        // vorheriger tiefer Punkt
                tris[12 * (i - 1) + 7] = (uint) (4 * i + 1);              // aktueller tiefer Punkt
                tris[12 * (i - 1) + 8] = (uint) (4 * (i - 1) + 1);        // vorheriger obiger Punkt

                // Dreieck unten
                tris[12 * (i - 1) + 9]  = (uint) (4 * segments + 1);      // Mittlepunkt unten
                tris[12 * (i - 1) + 10] = (uint) (4 * (i - 1) + 3);       // aktueller Segmentpunkt unten
                tris[12 * (i - 1) + 11] = (uint) (4 * i + 3);             // vorheriger Segmentpunkt unten
            }

            // Letztes Dreieck im tris Array eintragen (letzter Punkt mit ersten Punkt und Mittelpunkt)
            tris[(segments * 3) - 1] = (uint) segments;         
            tris[(segments * 3) - 2] = (uint) 0;
            tris[(segments * 3) - 3] = (uint) (segments - 1);

            /* Verts            Norms
                Kreis oben      Normal nach oben
                Kreis oben      Normal zur Seite
                Kreis unten     Normal zur Seite
                Kreis unten     Normal nach unten
                Reapeat         Repeat
            */

            /* Tris (Für vier Dreiecke(einen oben, zwei an der Seite*, einen unten) braucht man 12 Einträge beginnend mit i = 1 *Ein Viereck ergibt sich aus zwei Dreiecke*/

            //Erster Array Eintrag: (0, h/2, 0), Normals: (0, 1, 0)
            //Letzter Array Eintrag (0, -(h/2). 0), Normals: (0, -1, 0)

            
            Vertices = new MeshAttributes<float3>(verts);
            Normals = new MeshAttributes<float3>(norms);
            Triangles = new MeshAttributes<uint>(tris);
        }
    }

    public class ConeMesh : ConeFrustumMesh
    {
        public ConeMesh(float radius, float height, int segments) : base(radius, 0.0f, height, segments) { }
    }

    public class ConeFrustumMesh : Mesh
    {
        public ConeFrustumMesh(float radiuslower, float radiusupper, float height, int segments)
        {
            throw new NotImplementedException();
        }
    }

    public class PyramidMesh : Mesh
    {
        public PyramidMesh(float baselen, float height)
        {
            throw new NotImplementedException();
        }
    }

    public class TetrahedronMesh : Mesh
    {
        public TetrahedronMesh(float edgelen)
        {
            throw new NotImplementedException();
        }
    }

    public class TorusMesh : Mesh
    {
        public TorusMesh(float mainradius, float segradius, int segments, int slices)
        {
            throw new NotImplementedException();
        }
    }
}
