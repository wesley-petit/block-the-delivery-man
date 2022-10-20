using System.Collections.Generic;

public interface IScanReceiver
{
    public void OnScanReceive(in List<Boid> crowds);
}
