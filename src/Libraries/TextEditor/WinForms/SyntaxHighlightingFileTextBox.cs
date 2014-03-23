﻿using System;
using System.Windows.Forms;
using UILib.WinForms.Controls;

namespace TextEditor.WinForms
{
    public class SyntaxHighlightingFileTextBox : FileTextBox
    {
        public SyntaxHighlightingFileTextBox()
            : base(new SyntaxHighlightingTextBox())
        {
        }

        private SyntaxHighlightingTextBox HighlightingTextBox
        {
            get { return TextBox as SyntaxHighlightingTextBox; }
        }

        public ITextEditor Editor
        {
            get { return HighlightingTextBox.Editor; }
        }
    }

    internal class SyntaxHighlightingTextBox : ITextBox
    {
        private readonly TextEditorControl _control;

        internal ITextEditor Editor
        {
            get { return _control.Editor; }
        }

        public SyntaxHighlightingTextBox()
        {
            _control = new TextEditorControl();

            Editor.Multiline = false;
            Editor.TextChanged += (sender, args) => OnTextChanged(args);
            Editor.SetSyntax(StandardSyntaxType.FilePath);
        }

        public Control Control
        {
            get { return _control; }
        }

        public string Text
        {
            get { return _control.Text; }
            set { _control.Text = value; }
        }

        public bool ReadOnly
        {
            get { return _control.ReadOnly; }
            set { _control.ReadOnly = value; }
        }

        public BorderStyle BorderStyle
        {
            get { return _control.BorderStyle; }
            set { _control.BorderStyle = value; }
        }

        public event EventHandler TextChanged;

        protected virtual void OnTextChanged(EventArgs args)
        {
            if (TextChanged != null)
                TextChanged(this, args);
        }

        public void HighlightDragDrop()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void UnhighlightDragDrop()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
