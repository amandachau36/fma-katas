// using System;
//
// namespace ConferenceTrack.Business.Blocks
// {
//     public class Block
//     {
//         public string BlockName { get; }
//         
//         public double BlockDuration { get; }
//         public bool IsAllocated { get; private set; }
//         public TimeSpan TimeSlot { get; private set; }
//         
//         public string FormattedBlockNameAndTimeSlot { get; private set; }
//         
//
//         public void SetIsAllocated(bool isAllocated)
//         {
//             IsAllocated = isAllocated;
//         }
//
//         public void SetTalkTime(TimeSpan talkTime)
//         {
//             TimeSlot = talkTime;
//         }
//
//         public void SetScheduledTalk(string scheduledTalk)
//         {
//             FormattedBlockNameAndTimeSlot = scheduledTalk;
//         }
//     }
// }