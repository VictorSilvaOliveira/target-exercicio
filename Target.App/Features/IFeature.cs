namespace Target.App.Features;

public interface IFeature<T1, T2>
{
    T2 Executa(T1 request);
}