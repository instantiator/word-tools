# word-tools

PowerShell tools for puzzle solving.

## Prerequisites (OS X)

[Install](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-macos?view=powershell-7.2) and launch PowerShell:

```bash
$ brew install --cask powershell
$ pwsh
```

Import the module:

```powershell
PS word-tools> Import-Module ./WordToolsCmdlet.dll
```

## Simple queries

Read the word-list included in submodule `english-words` (from [dwyl/english-words](https://github.com/dwyl/english-words)):

```powershell
PS word-tools>  Read-Words -Path ./english-words/words_alpha.txt
```

Read the word-list, and filter to all words of length 4:

```powershell
PS word-tools>  Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Length 4
```

Read the word-list, and filter to all words matching crossword rule z??c:

```powershell
PS word-tools>  Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Crossword z??c
```

Read the word-list, and filter to all 

```powershell
PS word-tools> word-tools> Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -RegularExpression ^[ab][ab].+d$
```
