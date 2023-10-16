# CherryPicker.NET
GIT Tool to Automate cherry-pick.

Base user functionality.

1. collect commits from branch

	1.1 The user will specify which commits are needed to cherry-pick. All lists of commits will be exported in a JSON file.
	Filtering of commits will be done by organization/domain names.
	For exmaple:

	Commmits:
		adam.smith@company1.com
		albert.einstein@company2.com
		michael.faraday@Company1.com
	
	commits to cherry-pick will be filtered by 'company1','company2', 'all' (all inludes all commits)
	
	1.2 exported json file.
	{
		{
		  "hash": <hash>
		  "email": <email>
		  "author": <author>
		  "message" <message>
		}, ...
	}

	1.3 collector can have one external command "--consoleOut" to print human-readable table in terminal for further copy/paste to text editor for analyzation
	1.4

2. cherry pick to another branch.

Before using this command, user must checout the target branch.

2.2 select first commit to cherry-pick.
2.3 perform git cherry-pick <hash> command.
2.4 analize the result
2.5 if cherry-pick is successfull, continue with second one
2.6 if there is error, analize that,
	2.6.1
		- report about conflicts and perform 'cherry-pick --continue'
		- handle other errors ...