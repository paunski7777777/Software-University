using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class)]
public class CustomClassAttribute : Attribute
{
    public readonly string author;
    public readonly int revision;
    public readonly string description;
    public readonly List<string> reviewers;

    public CustomClassAttribute(string author, int revision, string description, params string[] inputReviewers)
    {
        this.author = author;
        this.revision = revision;
        this.description = description;
        this.reviewers = new List<string>();

        foreach (var reviewer in inputReviewers)
        {
            this.reviewers.Add(reviewer);
        }
    }
}