## .Net_Memory_Management(IDispose_Patterns)

Usecase 1- Without any dispose method/using block creating 'n' database connections and taking memory snapstots at various points.

### Memory Snapstot:

![alt text](https://github.com/avilavate/.Net_Memory_Management-IDispose_Patterns-/blob/master/without_dispose/dotMemory_SnapShots.jpg)

Usecase 2- With dispose method/using block creating 'n' database connections and taking memory snapstots at various points.

### Memory Snapstot:

![alt text](https://github.com/avilavate/.Net_Memory_Management-IDispose_Patterns-/blob/master/with_dispose/with_dispose.jpg)


Usecase 3- With dispose method/using block creating 'n' database connections on request and also creating 4MB of unmanaged recource (IntPtr pointing a 4MB memory block), taking memory snapstots at various points.

### Memory Snapstot:

![alt text](https://github.com/avilavate/.Net_Memory_Management-IDispose_Patterns-/blob/master/with_dispose/with_dispose(unmanaged_resource).jpg)
