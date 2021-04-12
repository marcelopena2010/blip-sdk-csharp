﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Messaging.Contents;
using Lime.Protocol;
using Lime.Protocol.Network;

namespace Take.Blip.Client
{
    /// <summary>
    /// Defines a service for sending messages, notifications and commands through an active connection.
    /// </summary>
    public interface ISender : IEstablishedSenderChannel, ICommandProcessor
    {
    }

    public static class SenderExtensions
    {
        /// <summary>
        /// Send a message through the available connection.
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="content">The content of the message</param>
        /// <param name="to">The destination of the message</param>
        /// <param name="cancellationToken">A cancellation token to allow the task to be canceled</param>
        public static Task SendMessageAsync(this ISender sender, string content, Node to, CancellationToken cancellationToken = default(CancellationToken))
            => sender.SendMessageAsync(new PlainText { Text = content } as Document, to, cancellationToken);

        /// <summary>
        /// Send a message through the available connection.
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="content">The content of the message</param>
        /// <param name="to">The destination of the message</param>
        /// <param name="cancellationToken">A cancellation token to allow the task to be canceled</param>
        public static Task SendMessageAsync(this ISender sender, Document content, Node to, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                To = to,
                Content = content
            };
            return sender.SendMessageAsync(message, cancellationToken);
        }
    }
}
