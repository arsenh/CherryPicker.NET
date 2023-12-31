﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Messages;

public class UserMessages
{
    // help messages for command line options
    public const string OptionMode = "Specifies the mode (collect,cherry-pick).";
    public const string OptionRepo = "Path to GIT repository.";
    public const string OptionDomains = "Domains.";
    public const string OptionFile = "Json file for cherry-pick.";

    // user messages
    public const string ModeIsNotSet = "Mode is not set.";
    public const string InvalidModeSet = "Ivalid mode set.";
    public const string UseHelpForInfo = "Use --help for information";
    public const string InvalidGitPath = "Invalid GIT repository path.";
    public const string RepoPathIsNotSet = "Repo path is not set.";
    public const string DomainsIsNotSet = "Domains is not set.";
    public const string JsonFilePathIsNotSet = "Json file path is not set.";
    public const string JsonFileIsCreated =  "{0} is created.";
    public const string UseCherryPick = "Use 'cherry-pick' mode to cherry-pick commits from the JSON file.";
    public const string CherryPickModeStarted = "Cherry-Pick mode started.";
    public const string CollectModeStarted = "Collect mode started.";
    public const string FileIsEmpty = "{0} file is empty. Nothing to do.";
    public const string GitShow = "Do you want to see changes (git show)";
    public const string EnterYesNoCharacters = "Please enter character from this list {y, n}: ";
    public const string EnterCherryPickCommandCharacters = "Please enter character from this list {c, a, e}: ";
    public const string WorkingCollectMode = "Working in collect mode.";
    public const string WorkingCherryPickMode = "Working in cherry-pick mode.";
    public const string PlatformNotSupported = "This platform not supported.";
    public const string PerformCherryPick = "Perform cherry-pick for {0} commit.";
    public const string WhatCherryPickOperationPerform = "What operation to perform (c/a/e) ?";
    public const string NoChangesNothingToCommit = "No changes; nothing to commit";
    public const string CommandCherryPickContinue = "c - continue (do after resolving conflicts manually)";
    public const string CommandCherryPickAbort = "a - abort";
    public const string CommandCherryPickExit = "e - exit from the program";
}
