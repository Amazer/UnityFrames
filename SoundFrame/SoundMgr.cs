using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public List<SoundChannel> channelsList = new List<SoundChannel>();
    private SoundChannel bgmChannel;
    private SoundChannel clickChannel;

    public SoundChannel BGMChannel
    {
        get
        {
            if (bgmChannel)
            {
                bgmChannel = SoundChannel.CreateChannel(this.transform, "BGM");
                channelsList.Add(bgmChannel);
            }
            return bgmChannel;
        }
    }
    public SoundChannel ClickChannel
    {
        get
        {
            if (clickChannel)
            {
                clickChannel = SoundChannel.CreateChannel(this.transform, "click");
                channelsList.Add(clickChannel);
            }
            return bgmChannel;
        }
    }

    public void MuteAll(bool mute)
    {
        var iter = channelsList.GetEnumerator();
        while (iter.MoveNext())
        {
             iter.Current.Mute(mute);
        }
    }
    public void StopAll()
    {
        var iter = channelsList.GetEnumerator();
        while (iter.MoveNext())
        {
             iter.Current.Stop();
        }
    }
}