using System.Threading;
using MediaBrowser.Controller.Session;
using MediaBrowser.Model.SyncPlay;

namespace MediaBrowser.Controller.SyncPlay.PlaybackRequests
{
    /// <summary>
    /// Class IgnoreWaitGroupRequest.
    /// </summary>
    public class IgnoreWaitGroupRequest : IGroupPlaybackRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreWaitGroupRequest"/> class.
        /// </summary>
        /// <param name="ignoreWait">Whether the client should be ignored.</param>
        public IgnoreWaitGroupRequest(bool ignoreWait)
        {
            IgnoreWait = ignoreWait;
        }

        /// <summary>
        /// Gets a value indicating whether the client should be ignored.
        /// </summary>
        /// <value>The client group-wait status.</value>
        public bool IgnoreWait { get; }

        /// <inheritdoc />
        public PlaybackRequestType Type { get; } = PlaybackRequestType.IgnoreWait;

        /// <inheritdoc />
        public void Apply(IGroupStateContext context, IGroupState state, SessionInfo session, CancellationToken cancellationToken)
        {
            state.HandleRequest(context, state.Type, this, session, cancellationToken);
        }
    }
}
