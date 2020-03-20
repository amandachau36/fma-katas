using System;

namespace DesignPatternIntro
{
    public class Canva
    {
        // Currently Tool is enum (Brush, Selection ...)
        private ITool _currentTool;

        public void SetCurrentTool(ITool tool)
        {
            _currentTool = tool;
        }

        public void MouseDown()
        {
         _currentTool.MouseDown();
        }

        public void MouseUp()
        {
           _currentTool.MouseUp();
        }
    }
}


