+++
title = "Getting Blur And DropShadow to work in the Windows Phone Emulator"
date = "2010-03-30T05:02:12Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone"]
draft = false
+++

I've noticed a few questions in the forums around why the Blur and DropShadow effects aren't showing up in the Windows Phone 7 Series emulator and the simple answer is you have to set CacheMode to BitmapCache.

```xml
<TextBlock Text="DropShadow" Foreground="Black" FontSize="48" CacheMode="BitmapCache">
    <TextBlock.Effect>
        <DropShadowEffect/>
    </TextBlock.Effect>
</TextBlock>

<TextBlock Text="Blur" Foreground="Black" FontSize="48" CacheMode="BitmapCache">
    <TextBlock.Effect>
        <BlurEffect/>
    </TextBlock.Effect>
</TextBlock>
```

We are working on setting this automatically so you don't have to scratch your head each time you apply an effect and wonder why it looks fine on the design surface yet doesn't show up in the emulator.

**UPDATE [7/20/2011]** - I was looking through my blog and realized this needs to be updated. For anyone still looking for this information all the effects such as Blur & DropShadow were intentionally disabled from the product for both 7.0 and the upcoming Mango. The performance hit that applications took from using these effects put too much of a strain on the system and it was decided that if we couldn't deliver a perfomant feature we would disable until such a time as we could.
