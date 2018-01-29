﻿#region license
// 
//      hypepool
//      https://github.com/bonesoul/hypepool
// 
//      Copyright (c) 2013 - 2018 Hüseyin Uslu
// 
//      Permission is hereby granted, free of charge, to any person obtaining a copy
//      of this software and associated documentation files (the "Software"), to deal
//      in the Software without restriction, including without limitation the rights
//      to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//      copies of the Software, and to permit persons to whom the Software is
//      furnished to do so, subject to the following conditions:
// 
//      The above copyright notice and this permission notice shall be included in all
//      copies or substantial portions of the Software.
// 
//      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//      IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//      FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//      AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//      LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//      OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//      SOFTWARE.
#endregion

using System.Linq;
using Hypepool.Common.Mining.Jobs;
using Hypepool.Common.Pools;
using Hypepool.Common.Shares;
using Stashbox;
using Stashbox.Infrastructure;

namespace Hypepool.Core.Internals.Factories.Pool
{
    public class PoolFactory : IPoolFactory
    {
        private readonly IDependencyResolver _container;

        public PoolFactory(IDependencyResolver container)
        {
            _container = container;
        }

        public PoolBase<TShare, TJob> GetPool<TShare, TJob>(string name) where TShare : IShare where TJob : IJob
        {
            var registrations = _container.ResolveAll<PoolBase<TShare, TJob>>();
            return registrations.First();
        }

        public IPoolContext<TJob> GetPoolContext<TJob>() where TJob : IJob
        {
            return _container.Resolve<IPoolContext<TJob>>();
        }
    }
}
