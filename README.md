# CherryPicker.NET
### GIT Tool to Automate cherry-pick.
Prerequisites: GIT version control tool.

Tool working in two modes collect and cherry-pick.

To getting information use `$ ./CherryPicker.NET --help`
```
CherryPicker.NET 1.0.0
Copyright (C) 2023 CherryPicker.NET

  -m, --mode       Required. Specifies the mode (collect, cherry-pick).

  -r, --repo       Required. Path to GIT repository.

  -d, --domains    Domains.

  -f, --file       Json file for cherry-pick.

  --help           Display this help screen.

  --version        Display version information.
```

Collect mode is used to filter out commits by domains.
For `max.planck@quantum.com` and `michael.faraday@physics.com`, the domains will be '`quantum`' and '`physics`'.
Usage: `$ ./CherryPicker.NET -m collect -r ./repo -d all`

After you will see the following message.
```
Working in collect mode.
Collect mode started.
collect_10_23_2023_9_22_56.json is created.
Use 'cherry-pick' mode to cherry-pick commits from the JSON file.
```
If you specify the `--domains` command as '`all`' then it will collect all commits in the repository.
If you have for example 'first', 'second', or 'third' domains and you want to specify which ones will be collected. 
For example, we want to collect only 'first' and 'third', then need to enter:

`$ ./CherryPicker.NET -m collect -r ./repo -d first third`

**NOTE: if you specify the 'all' domain with others, filtering will be ignored and will collect all commits.**


The generated JSON file includes all commits that needed to cherry-pick.

Cherry-pick mode is used to cherry-pick commits from JSON file.
Usage: 

`$ ./CherryPicker.NET -m cherry-pick -r ./repo -f collect_10_23_2023_9_22_56.json`

After you will see the following message.
```
Working in cherry-pick mode.
Cherry-Pick mode started.
selected collect_10_23_2023_9_22_56.json file.
Process: 3adfd6e26e85cf02066cf9083663f23e31be5acb commit
Do you want to see changes (git show) y/n ?:
```
After entering 'y' or 'n' next step is:
`Perform cherry-pick for 3adfd6e26e85cf02066cf9083663f23e31be5acb commit. y/n ?:`

If entered 'y' then commit will try to cherry-pick.
If conflicts occur, the following message will be visible
```
What operation to perform (c/a/e) ?
c - continue (do after resolving conflicts manually)
a - abort
e - exit from the program
Command:
```

Here you can enter '`c`' for perform `cherry-pick --continue`, '`a`' for `cherry-pick --abort`, and '`e`' for exit from the program.
