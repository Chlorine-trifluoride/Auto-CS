using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using AutoConsole;
using SDL2;

namespace AutoSDL
{
    class CarRenderer
    {
        private Car car;
        private IntPtr carTexture;
        private SDL.SDL_Rect dstRect;
        private SDL.SDL_Point center;

        private const int scale = 3;
        private int halfCarLen;

        public CarRenderer(Car car)
        {
            this.car = car;
        }
        
        public void LoadInit(IntPtr rendererPtr)
        {
            carTexture = SDL_image.IMG_LoadTexture(rendererPtr, "media/car_img.png");

            int w, h;
            SDL.SDL_QueryTexture(carTexture, out _, out _, out w, out h);

            dstRect.w = w * scale;
            dstRect.h = h * scale;

            center.x = w / 2 * scale;
            center.y = h / 2 * scale;

            halfCarLen = w / 2 * scale;
        }

        public void Cleanup()
        {
            SDL.SDL_DestroyTexture(carTexture);
        }

        public void Render(IntPtr rendererPtr, GameBase game)
        {
            // Edge wrap
            dstRect.x = (int)car.Position.X % game.WindowWidth;
            dstRect.y = (int)car.Position.Y % game.WindowHeight;

            // fix negatives
            if (dstRect.x < 0)
                dstRect.x += game.WindowWidth;

            if (dstRect.y < 0)
                dstRect.y += game.WindowHeight;

            // wrap when half off screen
            dstRect.x -= halfCarLen;
            dstRect.y -= halfCarLen;

            SDL.SDL_RenderCopyEx(rendererPtr, carTexture, IntPtr.Zero, ref dstRect,
                car.RotationDegrees, ref center, SDL.SDL_RendererFlip.SDL_FLIP_NONE);
        }
    }
}
