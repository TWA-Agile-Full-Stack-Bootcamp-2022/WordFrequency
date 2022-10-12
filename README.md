## refactoring step by step
1. refactor the code manually
2. please follow the refactor steps
3. follow small commit principle, commit code per refactoring
4. record code smell found and refactoring technique used in commit message
5. commit message should follow pattern like this: "refactor: [smell]: [technique]"

## Write down every refactoring step in here
1. Rename meaningless variables
2. Extract meaningful methods to reduce the size of the GetResult function
```
ConvertInputStringToWordList
DeduplicateWords
```
3. Remove useless data assignment, use `wordListWithoutDuplicate` in the next steps
```
inputWordList = wordListWithoutDuplicate;
```
4. Extract meaningful methods to reduce the size of the GetResult function
```
DescedingSortWordsByFrequency
GenerateWordFrequencyGameResult
```
5. Remove useless comments