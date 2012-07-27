﻿using System;

namespace Umbraco.Core.Resolving
{
	public class SingleResolved<TResolved>
	{
		TResolved _resolved;
		bool _canBeNull;

		public SingleResolved()
			: this(false)
		{ }

		public SingleResolved(TResolved value)
			: this(false)
		{
			_resolved = value;
		}

		public SingleResolved(bool canBeNull)
		{
			_canBeNull = canBeNull;
		}

		public SingleResolved(TResolved value, bool canBeNull)
		{
			_resolved = value;
			_canBeNull = canBeNull;
		}

		public TResolved Value
		{
			get
			{
				return _resolved;
			}

			set
			{
				Resolution.EnsureNotFrozen();

				if (!_canBeNull && value == null)
					throw new ArgumentNullException("value");
				_resolved = value;
			}
		}
	}
}