using System;
using System.Collections.Generic;
using System.Text;
using AutoConsole;
using SDL2;

namespace AutoSDL
{
    class Game1 : GameBase
    {
        private Car car;
        private UI ui;

        public Game1(int windowWidth, int windowHeight) : base(windowWidth, windowHeight)
        {

        }

        protected override void Init()
        {
            base.Init();

            car = new Car(new Vector2(48.0f, 48.0f), MathF.PI / 2);
            car.Renderer = new CarRenderer(car);

            ui = new UI(car);
        }

        protected override void Cleanup()
        {
            car.Renderer.Cleanup();
            ui.Cleanup();

            base.Cleanup();
        }

        protected override void Load(IntPtr rendererPtr)
        {
            car.Renderer.LoadInit(rendererPtr);
            ui.LoadInit(rendererPtr);
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
            ui.Update();
        }

        protected override void RenderScene(IntPtr rendererPtr)
        {
            SDL.SDL_RenderClear(rendererPtr);

            car.Renderer.Render(rendererPtr, this);
            ui.Render(rendererPtr, this);

            SDL.SDL_RenderPresent(rendererPtr);
        }
    }
}
