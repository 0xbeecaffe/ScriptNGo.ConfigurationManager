USE ConfigStore
GO
ALTER TABLE ConfigTargets drop constraint UC_TargetGroupTargetIP
GO
ALTER TABLE ConfigTargets add constraint UC_TargetGroupTargetIP unique (TargetGroup, TargetIP, Port)
GO