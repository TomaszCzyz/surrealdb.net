using SurrealDb.Net.Internals.Auth;

namespace SurrealDb.Net.Internals.Http;

internal class SurrealDbHttpEngineConfig
{
	public IAuth Auth { get; private set; } = new NoAuth();
	public string? Ns { get; private set; }
	public string? Db { get; private set; }

	private readonly Dictionary<string, object> _parameters = new();
	public IReadOnlyDictionary<string, object> Parameters => _parameters;

	public void Use(string ns, string? db)
	{
		Ns = ns;
		Db = db;
	}

	public void SetBasicAuth(string username, string? password)
	{
		Auth = new BasicAuth(username, password);
	}

	public void SetBearerAuth(string token)
	{
		Auth = new BearerAuth(token);
	}

	public void ResetAuth()
	{
		Auth = new NoAuth();
	}

	public void SetParam(string key, object value)
	{
		_parameters.Add(key, value);
	}

	public void RemoveParam(string key)
	{
		_parameters.Remove(key);
	}
}
