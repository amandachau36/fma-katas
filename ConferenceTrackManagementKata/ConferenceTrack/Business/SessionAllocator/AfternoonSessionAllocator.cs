// using System;
// using System.Collections.Generic;
// using ConferenceTrack.Client;
//
// namespace ConferenceTrack.Business.SessionAllocator
// {
//     public class AfternoonSessionAllocator : ISessionAllocator
//     {
//         public TimeSpan StartTime { get; }
//         public TimeSpan MinEndTime { get; }
//         public TimeSpan MaxEndTime { get; }
//         public List<List<Block>> Sessions { get; } = new List<List<Block>>();
//
//         public AfternoonSessionAllocator(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime)
//         {
//             StartTime = startTime;
//             MinEndTime = minEndTime;
//             MaxEndTime = maxEndTime;
//         }
//
//         public void AllocateTalksToSession(List<Block> availableTalks)
//         {
//
//             var time = StartTime;
//
//             var session = new List<Block>();
//
//             foreach (var talk in availableTalks)
//             {
//                 if (talk.IsAllocated) continue;
//
//                 var newTime = time.Add(TimeSpan.FromMinutes(talk.BlockDuration));
//
//                 if (newTime > MaxEndTime) continue;
//
//                 AddTalkToSession(session, talk, time);
//
//                 time = newTime;
//
//                 if (time > MinEndTime) break;  //TODO: should this be >=
//             }
//             
//             AddNetworkingEventToSession(session);
//                 
//             Sessions.Add(session);
//         }
//         
//         private void AddTalkToSession(List<Block> session, Block block, TimeSpan time)
//         {
//             session.Add(block);
//             
//             block.SetIsAllocated(true);
//                 
//             block.SetTimeSlot(time);
//         }
//         
//         private void AddNetworkingEventToSession(List<Block> allocatedTalks)
//         {
//             var networkingEvent = new Block("Networking Event", 60);
//             
//             networkingEvent.SetIsAllocated(true);
//             
//             networkingEvent.SetTimeSlot(MaxEndTime);
//             
//             allocatedTalks.Add(networkingEvent);
//         }
//     }
// }