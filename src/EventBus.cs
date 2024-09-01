using Akequ.Plugins.Plugin.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Akequ.Plugins.Plugin.Additional
{
    public class EventBus : Akequ.Base.Room
    {
        public override void Init()
        {
            if (netEvent.isServer)
            {
                HookManager.Add("onRoundStart()", (obj) =>
                {
                    onGameStart.run(obj);
                });

                HookManager.Add("onLCZDecontBegun", (obj) =>
                {
                    onLCZStart.run(obj);
                });

                HookManager.Add("onRoundEnd", (obj) =>
                {
                    onGameFinish.run(obj);
                });

                HookManager.Add("onPlayerDeath", (obj) =>
                {
                    onPlayerDie.run(obj);
                });

                HookManager.Add("onClassDEscape", (obj) =>
                {
                    onPlayerEscape.run(obj);
                });

                HookManager.Add("onScientistEscape", (obj) =>
                {
                    onPlayerEscape.run(obj);
                });

                HookManager.Add("onSupportSpawned", (obj) =>
                {
                    onSupportSpawned.run(obj);
                });

                HookManager.Add("onSupportRequest", (obj) =>
                {
                    onSupportRequest.run(obj);
                });
            }
        }

        public static Event onGameStart = new Event();
        public static Event onGameFinish = new Event();
        public static Event onPlayerDie = new Event();
        public static Event onPlayerEscape = new Event();
        public static Event onSupportSpawned = new Event();
        public static Event onSupportRequest = new Event();
        public static Event onLCZStart = new Event();
    }

    public delegate void Args(object[] obj);

    public class Event
    {
        public List<Args> events;

        public List<Args> eventsOnce;

        public void on(Args args)
        {
            events.Add(args);
        }

        public void once(Args args)
        {
            eventsOnce.Add(args);
        }

        public void clear()
        {
            events.Clear();
        }

        public void run(object[] obj)
        {
            events.ForEach(e =>
            {
                e(obj);
            });

            eventsOnce.ForEach(e =>
            {
                e(obj);
            });

            eventsOnce.Clear();
        }
    }
}