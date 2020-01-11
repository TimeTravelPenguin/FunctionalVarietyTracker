using System;

namespace FunctionalVarietyTracker.AutoDependencies
{
  [AttributeUsage(AttributeTargets.Class)]
  internal class AutoDependencyAttribute
    : Attribute
  {
    public bool RegisterAsSelf { get; }
    public bool IsSingleton { get; }

    public AutoDependencyAttribute(bool registerAsSelf, bool isSingleton = false)
    {
      RegisterAsSelf = registerAsSelf;
      IsSingleton = isSingleton;
    }
  }
}