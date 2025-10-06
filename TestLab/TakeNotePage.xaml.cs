namespace TestLab;

public partial class TakeNotePage : ContentPage
{
    const string NoteKey = "user_note";

    public TakeNotePage()
	{
		InitializeComponent();

        if (Preferences.ContainsKey(NoteKey))
        {
            SavedNoteLabel.Text = Preferences.Get(NoteKey, "");
        }
    }

    private void OnSaveNoteClicked(object sender, EventArgs e)
    {
        var noteText = NoteEditor.Text;

        if (string.IsNullOrWhiteSpace(noteText))
        {
            DisplayAlert("Thông báo", "Vui lòng nhập ghi chú trước khi lưu.", "OK");
            return;
        }

        Preferences.Set(NoteKey, noteText);

        SavedNoteLabel.Text = noteText;

        NoteEditor.Text = string.Empty;
    }
}
