**##Architectural Summary**

.NetCore 2.2 Console application with Unit test using MS Test Framework.

The solution consist of 2 projects- PokerGame and respective Test Project.

Input from text file is passed onto PokerService which validates the input and creates 2 Hand objects.
Upon creation each Hand gets a RankDecision which is calculated by the RankDeciders.

Winner is decided by comparison of RankDecision instances.


**##Setup**

Clone the repository.

Using cmd navigate to "*Repo*\PokerGame\bin\Release\netcoreapp2.2\publish" folder and run PokerGame.exe with below command

**PokerGame.exe _InputFileNameWithPath_**


  
  
