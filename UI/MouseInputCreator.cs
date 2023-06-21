using SmugBase.Logging;
using SmugMacros.Windows;
using MouseInput = SmugMacros.Input.MouseInput;

namespace SmugMacros.UI
{
    public partial class MouseInputCreator : Form
    {
        public MacroCreator ParentUI { get; }

        public MouseInput Output { get; private set; }

        public int OriginalIndex { get; internal set; }

        public MouseInputCreator(MacroCreator parentUI)
        {
            ParentUI = parentUI;
            Output = new MouseInput();
            OriginalIndex = -1;
            InitializeComponent();
        }

        public void UpdateForInput(MouseInput? mouseInput)
        {
            try
            {
                if (mouseInput == null)
                {
                    Output = new MouseInput();
                    OriginalIndex = -1;
                    MouseInputBox.Text = string.Empty;
                    MouseXDropDown.Value = 0;
                    MouseYDropDown.Value = 0;
                    return;
                }

                Output = mouseInput;
                switch (Output.MouseEvents)
                {
                    case MouseEvents.Move:
                        MouseInputBox.Text = "Move";
                        break;

                    case MouseEvents.LeftDown:
                        MouseInputBox.Text = "Left Down";
                        break;

                    case MouseEvents.LeftUp:
                        MouseInputBox.Text = "Left Up";
                        break;

                    case MouseEvents.RightDown:
                        MouseInputBox.Text = "Right Down";
                        break;

                    case MouseEvents.RightUp:
                        MouseInputBox.Text = "Right Up";
                        break;

                    case MouseEvents.MiddleDown:
                        MouseInputBox.Text = "Middle Down";
                        break;

                    case MouseEvents.MiddleUp:
                        MouseInputBox.Text = "Middle Up";
                        break;

                    case MouseEvents.XDown:
                        if (Output.MouseData == 0x0001)
                        {
                            MouseInputBox.Text = "Upper Side Down";
                        }
                        else if (Output.MouseData == 0x0002)
                        {
                            MouseInputBox.Text = "Lower Side Down";
                        }
                        break;

                    case MouseEvents.XUp:
                        if (Output.MouseData == 0x0001)
                        {
                            MouseInputBox.Text = "Upper Side Up";
                        }
                        else if (Output.MouseData == 0x0002)
                        {
                            MouseInputBox.Text = "Lower Side Up";
                        }
                        break;

                    default:
                        Program.Logger.Log("Encountered an unfamiliar Mouse Event when parsing a Mouse Input to the Mouse Input Creator: " + Output.MouseEvents, LogType.Warning);
                        break;
                }

                MouseXDropDown.Value = Output.MousePosition.X;
                MouseYDropDown.Value = Output.MousePosition.Y;
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while parsing a Mouse Input to the Mouse Input Creator: " + exception.Message, LogType.Error);
            }
        }

        private void SaveOutput()
        {
            switch (MouseInputBox.Text)
            {
                case "Move":
                    Output.MouseEvents = MouseEvents.Move;
                    break;

                case "Left Down":
                    Output.MouseEvents = MouseEvents.LeftDown;
                    break;

                case "Left Up":
                    Output.MouseEvents = MouseEvents.LeftUp;
                    break;

                case "Right Down":
                    Output.MouseEvents = MouseEvents.RightDown;
                    break;

                case "Right Up":
                    Output.MouseEvents = MouseEvents.RightUp;
                    break;

                case "Middle Down":
                    Output.MouseEvents = MouseEvents.MiddleDown;
                    break;

                case "Middle Up":
                    Output.MouseEvents = MouseEvents.MiddleUp;
                    break;

                case "Upper Side Down":
                    Output.MouseEvents = MouseEvents.XDown;
                    Output.MouseData = 0x0001;
                    break;

                case "Upper Side Up":
                    Output.MouseEvents = MouseEvents.XUp;
                    Output.MouseData = 0x0001;
                    break;

                case "Lower Side Down":
                    Output.MouseEvents = MouseEvents.XDown;
                    Output.MouseData = 0x0002;
                    break;

                case "Lower Side Up":
                    Output.MouseEvents = MouseEvents.XUp;
                    Output.MouseData = 0x0002;
                    break;
            }

            Output.MousePosition = new Point((int)MouseXDropDown.Value, (int)MouseYDropDown.Value);
            Output.Input = Output.ToInput();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (MouseInputBox.Text == string.Empty)
            {
                MessageBox.Show("Please make sure all fields are appropriately filled in!");
                return;
            }

            try
            {
                SaveOutput();
                if (OriginalIndex == -1)
                {
                    ParentUI.MacroInputs.Add(Output);
                }
                else
                {
                    ParentUI.MacroInputs[OriginalIndex] = Output;
                }
            }
            catch (Exception exception)
            {
                Program.Logger.Log("An error occured while trying to save a Mouse Input: " + exception, LogType.Error);
            }
            finally
            {
                Hide();
                ParentUI.RefreshInputDisplay();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Hide();
    }
}
