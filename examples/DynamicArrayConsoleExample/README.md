# Console output

```txt
----------------------------------------------
             DynamicArray example
----------------------------------------------
Size: 2, capacity: 4

 Dynamic array [02]: 7 7
Internal array [04]: 7 7 0 0

Push back 6 times:

 Dynamic array [03]: 7 7 0
Internal array [04]: 7 7 0 0

 Dynamic array [04]: 7 7 0 1
Internal array [08]: 7 7 0 1 0 0 0 0

 Dynamic array [05]: 7 7 0 1 2
Internal array [08]: 7 7 0 1 2 0 0 0

 Dynamic array [06]: 7 7 0 1 2 3
Internal array [08]: 7 7 0 1 2 3 0 0

 Dynamic array [07]: 7 7 0 1 2 3 4
Internal array [08]: 7 7 0 1 2 3 4 0

 Dynamic array [08]: 7 7 0 1 2 3 4 5
Internal array [16]: 7 7 0 1 2 3 4 5 0 0 0 0 0 0 0 0

Pop back 6 times:

 Dynamic array [07]: 7 7 0 1 2 3 4
Internal array [16]: 7 7 0 1 2 3 4 0 0 0 0 0 0 0 0 0

 Dynamic array [06]: 7 7 0 1 2 3
Internal array [16]: 7 7 0 1 2 3 0 0 0 0 0 0 0 0 0 0

 Dynamic array [05]: 7 7 0 1 2
Internal array [16]: 7 7 0 1 2 0 0 0 0 0 0 0 0 0 0 0

 Dynamic array [04]: 7 7 0 1
Internal array [08]: 7 7 0 1 0 0 0 0

 Dynamic array [03]: 7 7 0
Internal array [08]: 7 7 0 0 0 0 0 0

 Dynamic array [02]: 7 7
Internal array [08]: 7 7 0 0 0 0 0 0

Set size = 10:

 Dynamic array [10]: 7 7 0 0 0 0 0 0 0 0
Internal array [20]: 7 7 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0

Set size = 3:

 Dynamic array [03]: 7 7 0
Internal array [06]: 7 7 0 0 0 0

Set size = 2:

 Dynamic array [02]: 7 7
Internal array [06]: 7 7 0 0 0 0

Insert -8 at index 1:

 Dynamic array [03]: 7 -8 7
Internal array [06]: 7 -8 7 0 0 0
