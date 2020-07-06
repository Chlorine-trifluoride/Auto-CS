using System;
using System.Collections.Generic;
using System.Text;
using AutoConsole;
using SDL2;

namespace AutoSDL
{
    class Game1 : GameBase
    {
        private bool[] keys;
        private Car car;

        public Game1(int windowWidth, int windowHeight) : base(windowWidth, windowHeight)
        {

        }

        protected override void Init()
        {
            base.Init();

            car = new Car();
            car.Renderer = new CarRenderer(car);
        }

        protected override void Cleanup()
        {
            car.Renderer.Cleanup();

            base.Cleanup();
        }

        protected override void Load(IntPtr rendererPtr)
        {
            car.Renderer.LoadInit(rendererPtr);
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_w))
                car.Accelerate();

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_s))
                car.Decelerate();

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_a))
                car.SteerLeft();

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_d))
                car.SteerRight();

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_z))
                car.TurnEngineOn();

            if (InputManager.GetKeyState(SDL.SDL_Keycode.SDLK_x))
                car.TurnEngineOff();

            car.Update(deltaTime);
        }

        protected override void RenderScene(IntPtr rendererPtr)
        {
            SDL.SDL_RenderClear(rendererPtr);

            car.Renderer.Render(rendererPtr);

            SDL.SDL_RenderPresent(rendererPtr);
        }
    }
}
