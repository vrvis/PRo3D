﻿// Learn more about F# at http://fsharp.org

open System

open Aardvark.Base
open Aardvark.GeoSpatial.Opc
open Aardvark.Opc

type Kind = Scene | Annotations

[<EntryPoint>]
let main argv =
    
    let kind = Annotations

    let jezero =
        { 
            useCompressedTextures = true
            preTransform     = Trafo3d.Identity
            patchHierarchies = 
                    Seq.delay (fun _ -> 
                        System.IO.Directory.GetDirectories(@"I:\OPC\2020-08-06-Jezero-OPC") 
                        |> Seq.collect System.IO.Directory.GetDirectories
                    )
            boundingBox      = Box3d.Parse("[[709869.947406691, 3140052.258326461, 1075121.095408683], [710116.986329168, 3140296.918390740, 1075374.689812710]]") 
            near             = 0.1
            far              = 10000.0
            speed            = 5.0
            lodDecider       =  DefaultMetrics.mars2 
        }

    match  kind with
    | Scene ->
    
        TestViewer.run jezero

    | Annotations ->

        let scene =
            { 
                useCompressedTextures = true
                preTransform     = Trafo3d.Identity
                patchHierarchies = 
                        Seq.delay (fun _ -> 
                            System.IO.Directory.GetDirectories(@"I:\OPC\Shaler_OPCs_2019\Shaler_Navcam") 
                            |> Seq.collect System.IO.Directory.GetDirectories
                        )
                boundingBox      = Box3d.Parse("[[-2490137.664354247, 2285874.562728135, -271408.476700304], [-2490136.248131170, 2285875.658034266, -271406.605430601]]") 
                near             = 0.1
                far              = 10000.0
                speed            = 5.0
                lodDecider       =  DefaultMetrics.mars2 
            }

        let scene =
            { 
                useCompressedTextures = true
                preTransform     = Trafo3d.Identity
                patchHierarchies = 
                        Seq.delay (fun _ -> 
                            System.IO.Directory.GetDirectories(@"F:\pro3d\data\20200220_DinosaurQuarry2") 
                            |> Seq.collect System.IO.Directory.GetDirectories
                        )
                boundingBox      = Box3d.Parse("[[-15.699694740, 4.338130733, -0.514935397], [-4.960646670, 36.914955133, 5.004174588]]") 
                near             = 0.1
                far              = 10000.0
                speed            = 5.0
                lodDecider       =  DefaultMetrics.mars2 
            }

        let scene =
            { 
                useCompressedTextures = true
                preTransform     = Trafo3d.Identity
                patchHierarchies = 
                    Seq.delay (fun _ -> 
                        System.IO.Directory.GetDirectories(@"F:\pro3d\data\20200220_DinosaurQuarry2") 
                        |> Seq.collect System.IO.Directory.GetDirectories
                    )
                boundingBox      = Box3d.Parse("[[-15.699694740, 4.338130733, -0.514935397], [-4.960646670, 36.914955133, 5.004174588]]") 
                near             = 0.1
                far              = 10000.0
                speed            = 5.0
                lodDecider       =  DefaultMetrics.mars2 
            }

        //let scene =
        //    { 
        //        useCompressedTextures = true
        //        preTransform     = Trafo3d.Identity
        //        patchHierarchies = 
        //                System.IO.Directory.GetDirectories(@"F:\pro3d\data\20200220_DinosaurQuarry2") 
        //                |> Seq.collect System.IO.Directory.GetDirectories
        //        boundingBox      = Box3d.Parse("[[-9.996176625, 1.249114172, -1.937521343], [-0.603052397, 27.938626479, -0.132129824]]") 
        //        near             = 0.1
        //        far              = 10000.0
        //        speed            = 5.0
        //        lodDecider       =  DefaultMetrics.mars2 
        //    }

        let scene =
            { 
                useCompressedTextures = true
                preTransform     = Trafo3d.Identity
                patchHierarchies = 
                    Seq.delay (fun _ -> 
                        System.IO.Directory.GetDirectories(@"F:\pro3d\data\OpcMcz") 
                    )
                boundingBox      = Box3d.Parse("[[699507.902347501, 3142696.785742886, 1072717.259930025], [699508.165976587, 3142697.102699531, 1072717.505653937]]") 
                near             = 0.1
                far              = 10000.0
                speed            = 5.0
                lodDecider       =  DefaultMetrics.mars2 
            }

        //let scene =
        //    { 
        //        useCompressedTextures = true
        //        preTransform     = Trafo3d.Identity
        //        patchHierarchies = 
        //            Seq.delay (fun _ -> 
        //                System.IO.Directory.GetDirectories(@"F:\pro3d\data\OpcHera") 
        //            )
        //        boundingBox      = Box3d.Parse("[[-0.089070135, -0.087013945, -0.056419425], [0.086516376, 0.000000000, 0.058683879]]") 
        //        near             = 0.1
        //        far              = 10000.0
        //        speed            = 5.0
        //        lodDecider       =  DefaultMetrics.mars2 
        //    }

        //let scene =
        //    { 
        //        useCompressedTextures = true
        //        preTransform     = Trafo3d.Identity
        //        patchHierarchies = 
        //            Seq.delay (fun _ -> 
        //                System.IO.Directory.GetDirectories(@"F:\pro3d\data\dimorphos") 
        //            )
        //        boundingBox      = Box3d.Parse("[[-89.181903827, -87.182643300, -56.420779204], [86.522432535, 0.000000000, 58.710996093]]") 
        //        near             = 0.1
        //        far              = 10000.0
        //        speed            = 5.0
        //        lodDecider       =  DefaultMetrics.mars2 
        //    }

        Aardvark.Rendering.GL.RuntimeConfig.UseNewRenderTask <- true

        let annotations = @"I:\OPC\Shaler_OPCs_2019\crazy2.pro3d.ann"
        let annotations = @"F:\pro3d\data\20200220_DinosaurQuarry2\strangetest.pro3d.ann"
        let annotations = @"F:\pro3d\data\OpcHera\annos2.pro3d.ann"
        //let annotations = @"F:\pro3d\data\OpcMcz\singleAnno.pro3d.ann"
        let annotations = @"F:\pro3d\data\OpcMcz\blub.pro3d.ann"
        let annotations = @"F:\pro3d\data\OpcMcz\notworking.pro3d.ann"
        //let annotations = @"F:\pro3d\data\OpcMcz\heavy.pro3d.ann"
        //let annotations = @"F:\pro3d\data\dimorphos\singleanno.pro3d.ann"

        let annotations = 
            PRo3D.Core.Drawing.DrawingUtilities.IO.loadAnnotationsFromFile annotations

        FSharp.Data.Adaptive.ShallowEqualityComparer.Set {
            new System.Collections.Generic.IEqualityComparer<Trafo3d> with
                member x.GetHashCode _ = 0
                member x.Equals(_,_) = false
            }

        AnnotationViewer.run scene annotations

