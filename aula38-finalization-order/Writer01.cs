using System;
using System.IO;

class StreamFlushable : StreamWriter, IDisposable{
    public StreamFlushable(Stream dest) : base(dest) {}
    public StreamFlushable(string path) : base(new FileStream(path, FileMode.Create)) {}
    public new void Dispose() { 
        Console.WriteLine("Diposing...");
        base.Dispose();
    }
    ~StreamFlushable() {
        Console.WriteLine("finalizing...");
        base.Flush(); // !!!!!! Não aceder a recursos Nativos ou Disposable no Finalize.
        // Chamadad implícita ao Finalize da base
    }
}

static class App{

	public static void Main(){
        // WriteOnly();
        // WriteAndFlush();
        // WriteAndDispose();
        // WriteOnFLushable();
        WriteOnFLushableLazy();        
        Console.WriteLine("Wait for user to hit <Enter>");
		Console.ReadLine();
	}
    
    static void WriteOnly() {
        Console.WriteLine("Write and forget to flush and dispose...");
        StreamWriter fs = new StreamWriter(new FileStream("out.txt", FileMode.Create));
		fs.Write("Ola ");
        fs.WriteLine("Mundo");
        fs.WriteLine("Adeus 123");
        // Finalize não faz Flush()
    }
    
    static void WriteAndFlush() {
        Console.WriteLine("Write and flush...");
        StreamWriter fs = new StreamWriter(new FileStream("out.txt", FileMode.Create));
		fs.Write("Ola ");
        fs.WriteLine("Mundo");
        fs.WriteLine("Adeus 123");
        fs.Flush();
        // Finalize NÃO faz Flush()
    }

    static void WriteAndDispose() {
        using(StreamWriter fs = new StreamWriter(new FileStream("out.txt", FileMode.Create))){
            Console.WriteLine("Write and dispose...");
            fs.Write("Ola ");
            fs.WriteLine("Mundo");
            fs.WriteLine("Adeus Dispose");
            // Dispose() => Flush();
            Console.WriteLine("Wait for user to hit <Enter>");
        	Console.ReadLine();
        } 
    }
    
    static void WriteOnFLushable() {
        Console.WriteLine("Write and forget to flush and dispose...");
        StreamWriter fs = new StreamFlushable(new FileStream("out.txt", FileMode.Create));
		fs.Write("Ola ");
        fs.WriteLine("Mundo");
        fs.WriteLine("Adeus 123");
        // Finalize FAZ Flush() => !!!! Perigoso
    }
    
    static void WriteOnFLushableLazy() {
        Console.WriteLine("Write and forget to flush and dispose...");
        StreamWriter fs = new StreamFlushable("out.txt");
		fs.Write("Ola ");
        fs.WriteLine("Mundo");
        fs.WriteLine("Adeus 123");
    }
}

