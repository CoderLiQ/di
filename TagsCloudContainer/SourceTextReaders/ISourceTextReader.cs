﻿namespace TagsCloudContainer.SourceTextReaders
{
    public interface ISourceTextReader
    {
        string[] ReadText(string filePath);
    }
}