using System.Collections.Generic;
using System.Globalization;
using Xunit.Internal;

namespace Xunit.v3;

/// <summary>
/// This message is sent during execution to indicate that the Before method of a
/// <see cref="T:Xunit.Sdk.BeforeAfterTestAttribute"/> has completed executing.
/// </summary>
[JsonTypeID("before-test-finished")]
public class _BeforeTestFinished : _TestMessage
{
	string? attributeName;

	/// <summary>
	/// Gets or sets the fully qualified type name of the <see cref="T:Xunit.Sdk.BeforeAfterTestAttribute"/>.
	/// </summary>
	public string AttributeName
	{
		get => this.ValidateNullablePropertyValue(attributeName, nameof(AttributeName));
		set => attributeName = Guard.ArgumentNotNull(value, nameof(AttributeName));
	}

	internal override void Serialize(JsonObjectSerializer serializer)
	{
		base.Serialize(serializer);

		serializer.Serialize(nameof(AttributeName), AttributeName);
	}

	/// <inheritdoc/>
	public override string ToString() =>
		string.Format(CultureInfo.CurrentCulture, "{0} attr={1}", base.ToString(), attributeName.Quoted());

	/// <inheritdoc/>
	protected override void ValidateObjectState(HashSet<string> invalidProperties)
	{
		base.ValidateObjectState(invalidProperties);

		ValidatePropertyIsNotNull(attributeName, nameof(AttributeName), invalidProperties);
	}
}
