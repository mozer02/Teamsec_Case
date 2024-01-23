namespace Teamsec_Case.Core.application
{
    public interface IApplicationService<in TRequest, out TResponse>
    {
        TResponse OnProcess(TRequest @request = default(TRequest));
    }
}
