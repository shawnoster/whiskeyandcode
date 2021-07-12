+++
title = "Unable to Clear East Asian Text from a TextBox in Windows Phone (or always clear your TextBox focus)"
date = "2012-04-24T01:30:29Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone"]
draft = false
+++

We've received several reports of apps that don't clear out their text even though the app author is setting the Text property to an empty string. I did a little poking and it's due to a combination of the application bar and IME. The onscreen keyboard (SIP) enters a composition mode when working with East Asian languages that allows for quickly entering complex words and phrases and it ends once the SIP is dismissed. If the text is modified programmatically while it's in this mode it'll behave unpredictably, the most obvious issue being that it doesn't update to reflect the text you've set in your code behind.

You can tell if a TextBox is in this mode by the underline underneath the current character you're editing:

[![image](/images/image_thumb_8.png "image")](/images/image_8.png)

Because the ApplicationBar isn't drawn or managed by Silverlight focus won't properly be taken away from the currently active control (the TextBox) and any attempt to change the text via the Text property will put the TextBox into the state I mentioned above. The most common way this happens is performing some action on the text such as sending a message and then attempting to clear it out.

```csharp
private void ApplicationBarIconButton_Click(object sender, EventArgs e)
{
    ChatUpFriend(MessageTextBox.Text);

    MessageTextBox.Text = "";
}
```

Luckily the work around is easy, force the SIP to be dismissed before clearing the Text property and everything will work as expected. The most common/easiest way is to set focus to the page itself:

```csharp
private void ApplicationBarIconButton_Click(object sender, EventArgs e)
{
    // Set focus to the page ensuring all TextBox controls are properly committed
    // and that the IME session has been correctly closed.
    this.Focus();

    ChatUpFriend(MessageTextBox.Text);

    MessageTextBox.Text = "";
}
```

I recommend putting this code anywhere you're clearing out a TextBox as you never know what language your users will be typing in.
