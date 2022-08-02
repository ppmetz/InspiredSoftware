# FilePath

the file path type behaves similiar like a string but it's ignoring upper and lower case differences.
instance can be created due to implicit operator not only with the 'new' keyword, but with assignment operator.
F.eg.:


            string TempFile => System.IO.Path.GetTempFileName();

            var instance = new FilePath(TempFile);
            
            FilePath instance2 = (FilePath)TempFile;
            
            FilePath instance3 = TempFile;
            
