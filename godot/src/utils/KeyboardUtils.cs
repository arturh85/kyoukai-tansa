namespace ankitaiso.utils;

using System;
using Godot;

public static class KeyboardUtils {
  public static string KeyToString(Key key) {
    switch (key) {
      case Key.None:
        return "";
      case Key.Special:
        return "";
      case Key.Escape:
        return "";
      case Key.Tab:
        return "";
      case Key.Backtab:
        return "";
      case Key.Backspace:
        return "";
      case Key.Enter:
        return "";
      case Key.KpEnter:
        return "";
      case Key.Insert:
        return "";
      case Key.Delete:
        return "";
      case Key.Pause:
        return "";
      case Key.Print:
        return "";
      case Key.Sysreq:
        return "";
      case Key.Clear:
        return "";
      case Key.Home:
        return "";
      case Key.End:
        return "";
      case Key.Left:
        return "";
      case Key.Up:
        return "";
      case Key.Right:
        return "";
      case Key.Down:
        return "";
      case Key.Pageup:
        return "";
      case Key.Pagedown:
        return "";
      case Key.Shift:
        return "";
      case Key.Ctrl:
        return "";
      case Key.Meta:
        return "";
      case Key.Alt:
        return "";
      case Key.Capslock:
        return "";
      case Key.Numlock:
        return "";
      case Key.Scrolllock:
        return "";
      case Key.F1:
        return "";
      case Key.F2:
        return "";
      case Key.F3:
        return "";
      case Key.F4:
        return "";
      case Key.F5:
        return "";
      case Key.F6:
        return "";
      case Key.F7:
        return "";
      case Key.F8:
        return "";
      case Key.F9:
        return "";
      case Key.F10:
        return "";
      case Key.F11:
        return "";
      case Key.F12:
        return "";
      case Key.F13:
        return "";
      case Key.F14:
        return "";
      case Key.F15:
        return "";
      case Key.F16:
        return "";
      case Key.F17:
        return "";
      case Key.F18:
        return "";
      case Key.F19:
        return "";
      case Key.F20:
        return "";
      case Key.F21:
        return "";
      case Key.F22:
        return "";
      case Key.F23:
        return "";
      case Key.F24:
        return "";
      case Key.F25:
        return "";
      case Key.F26:
        return "";
      case Key.F27:
        return "";
      case Key.F28:
        return "";
      case Key.F29:
        return "";
      case Key.F30:
        return "";
      case Key.F31:
        return "";
      case Key.F32:
        return "";
      case Key.F33:
        return "";
      case Key.F34:
        return "";
      case Key.F35:
        return "";
      case Key.KpMultiply:
        return "*";
      case Key.KpDivide:
        return "/";
      case Key.KpSubtract:
        return "-";
      case Key.KpPeriod:
        return ".";
      case Key.KpAdd:
        return "+";
      case Key.Kp0:
        return "0";
      case Key.Kp1:
        return "1";
      case Key.Kp2:
        return "2";
      case Key.Kp3:
        return "3";
      case Key.Kp4:
        return "4";
      case Key.Kp5:
        return "5";
      case Key.Kp6:
        return "6";
      case Key.Kp7:
        return "7";
      case Key.Kp8:
        return "8";
      case Key.Kp9:
        return "9";
      case Key.Menu:
        return "";
      case Key.Hyper:
        return "";
      case Key.Help:
        return "";
      case Key.Back:
        return "";
      case Key.Forward:
        return "";
      case Key.Stop:
        return "";
      case Key.Refresh:
        return "";
      case Key.Volumedown:
        return "";
      case Key.Volumemute:
        return "";
      case Key.Volumeup:
        return "";
      case Key.Mediaplay:
        return "";
      case Key.Mediastop:
        return "";
      case Key.Mediaprevious:
        return "";
      case Key.Medianext:
        return "";
      case Key.Mediarecord:
        return "";
      case Key.Homepage:
        return "";
      case Key.Favorites:
        return "";
      case Key.Search:
        return "";
      case Key.Standby:
        return "";
      case Key.Openurl:
        return "";
      case Key.Launchmail:
        return "";
      case Key.Launchmedia:
        return "";
      case Key.Launch0:
        return "";
      case Key.Launch1:
        return "";
      case Key.Launch2:
        return "";
      case Key.Launch3:
        return "";
      case Key.Launch4:
        return "";
      case Key.Launch5:
        return "";
      case Key.Launch6:
        return "";
      case Key.Launch7:
        return "";
      case Key.Launch8:
        return "";
      case Key.Launch9:
        return "";
      case Key.Launcha:
        return "";
      case Key.Launchb:
        return "";
      case Key.Launchc:
        return "";
      case Key.Launchd:
        return "";
      case Key.Launche:
        return "";
      case Key.Launchf:
        return "";
      case Key.Globe:
        return "";
      case Key.Keyboard:
        return "";
      case Key.JisEisu:
        return "";
      case Key.JisKana:
        return "";
      case Key.Unknown:
        return "";
      case Key.Space:
        return " ";
      case Key.Exclam:
        return "";
      case Key.Quotedbl:
        return "";
      case Key.Numbersign:
        return "";
      case Key.Dollar:
        return "$";
      case Key.Percent:
        return "%";
      case Key.Ampersand:
        return "&";
      case Key.Apostrophe:
        return "'";
      case Key.Parenleft:
        return "(";
      case Key.Parenright:
        return ")";
      case Key.Asterisk:
        return "*";
      case Key.Plus:
        return "+";
      case Key.Comma:
        return ",";
      case Key.Minus:
        return "-";
      case Key.Period:
        return ".";
      case Key.Slash:
        return "/";
      case Key.Key0:
        return "0";
      case Key.Key1:
        return "1";
      case Key.Key2:
        return "2";
      case Key.Key3:
        return "3";
      case Key.Key4:
        return "4";
      case Key.Key5:
        return "5";
      case Key.Key6:
        return "6";
      case Key.Key7:
        return "7";
      case Key.Key8:
        return "8";
      case Key.Key9:
        return "9";
      case Key.Colon:
        return ":";
      case Key.Semicolon:
        return ";";
      case Key.Less:
        return "<";
      case Key.Equal:
        return "=";
      case Key.Greater:
        return ">";
      case Key.Question:
        return "?";
      case Key.At:
        return "@";
      case Key.A:
        return "a";
      case Key.B:
        return "b";
      case Key.C:
        return "c";
      case Key.D:
        return "d";
      case Key.E:
        return "e";
      case Key.F:
        return "f";
      case Key.G:
        return "g";
      case Key.H:
        return "h";
      case Key.I:
        return "i";
      case Key.J:
        return "j";
      case Key.K:
        return "k";
      case Key.L:
        return "l";
      case Key.M:
        return "m";
      case Key.N:
        return "n";
      case Key.O:
        return "o";
      case Key.P:
        return "p";
      case Key.Q:
        return "q";
      case Key.R:
        return "r";
      case Key.S:
        return "s";
      case Key.T:
        return "t";
      case Key.U:
        return "u";
      case Key.V:
        return "v";
      case Key.W:
        return "w";
      case Key.X:
        return "x";
      case Key.Y:
        return "y";
      case Key.Z:
        return "z";
      case Key.Bracketleft:
        return "[";
      case Key.Backslash:
        return "\\";
      case Key.Bracketright:
        return "]";
      case Key.Asciicircum:
        return "";
      case Key.Underscore:
        return "_";
      case Key.Quoteleft:
        return "";
      case Key.Braceleft:
        return "{";
      case Key.Bar:
        return " ";
      case Key.Braceright:
        return "}";
      case Key.Asciitilde:
        return "";
      case Key.Yen:
        return "";
      case Key.Section:
        return "";
      default:
        throw new ArgumentOutOfRangeException(nameof(key), key, null);
    }
  }

}
