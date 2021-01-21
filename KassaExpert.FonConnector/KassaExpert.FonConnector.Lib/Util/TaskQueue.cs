using System;
using System.Threading;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.Lib.Util
{
    internal sealed class TaskQueue
    {
        private readonly SemaphoreSlim _semaphore;

        public TaskQueue()
        {
            _semaphore = new SemaphoreSlim(1);
        }

        public async Task<T> Enqueue<T>(Func<Task<T>> task)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await task();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Enqueue(Action action)
        {
            await _semaphore.WaitAsync();
            try
            {
                action.Invoke();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<T> Enqueue<T>(Func<T> action)
        {
            await _semaphore.WaitAsync();
            try
            {
                return action.Invoke();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Enqueue(Func<Task> task)
        {
            await _semaphore.WaitAsync();
            try
            {
                await task();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}