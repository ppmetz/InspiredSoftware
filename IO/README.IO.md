# FilePath

the file path type behaves similiar like a string but it's ignoring upper and lower case differences.
instance can be created due to implicit operator not only with the 'new' keyword, but with assignment operator.
F.eg.:


            string tempFile = System.IO.Path.GettempFileName();

            var instance = new FilePath(tempFile);
            
            FilePath instance2 = (FilePath)tempFile;
            
            FilePath instance3 = tempFile;
            
