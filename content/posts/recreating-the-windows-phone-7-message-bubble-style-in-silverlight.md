+++
title = "Recreating the Windows Phone 7 message “bubble” style in Silverlight"
date = "2011-07-22T23:16:52Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone", "XAML", "Silverlight"]
draft = false
+++

In a little app I'm working on to exercise some new Mango features I needed to create the message "bubble" and oddly enough didn't stumble across any samples I could easily use even though a large number of apps have recreated this style, most likely because it's so easy to do.

[![image](/images/image_thumb_5.png "image")](/images/image_5.png)

Here was my first take and it's very hard-coded to the above look but it should be trivial to change it around. Also there are dozen ways you could make this more reusable, either as a template for a `ContentControl` or as a new control. If anyone has any suggestions for improvements or a better resource I'd love to see it!

## XAML

```xml
<!-- bubble -->
<Grid Grid.Column="1"
    Margin="12,6,12,0">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <Path Data="M 16,12 16,0 0,12"
        Fill="{StaticResource PhoneAccentBrush}"
        HorizontalAlignment="Right"
        Margin="0,0,12,0"
        UseLayoutRounding="False"
        VerticalAlignment="Top" />

    <!-- Your actual content here -->
    <StackPanel Grid.Row="1"
        Background="{StaticResource PhoneAccentBrush}">
        <TextBlock Text="{Binding Mood}"
            Style="{StaticResource PhoneTextNormalStyle}"
            FontWeight="Bold"
            TextWrapping="Wrap"
            Margin="6,12,6,6"
            HorizontalAlignment="Left"
            VerticalAlignment="Top" />

        <TextBlock Text="{Binding LastUpdated, StringFormat='g'}"
            HorizontalAlignment="Right"
            VerticalAlignment="Top"
            Margin="6,0,6,6"
            Style="{StaticResource PhoneTextSubtleStyle}"
            FontFamily="Segoe WP SemiLight" />
    </StackPanel>
</Grid>
```

Note for the sharp-eyed I'm using a feature that is new for Mango that exists in Silverlight 4 which is default string formatting in bindings.
