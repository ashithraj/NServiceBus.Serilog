﻿using NServiceBus.Features;

class SagaTracingFeature : Feature
{
    public SagaTracingFeature()
    {
        DependsOn<Sagas>();
        DependsOn<TracingFeature>();
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        var pipeline = context.Pipeline;
        pipeline.Register(new CaptureSagaStateBehavior.Registration());
        pipeline.Register(new CaptureSagaResultingMessagesBehavior.Registration());
    }
}