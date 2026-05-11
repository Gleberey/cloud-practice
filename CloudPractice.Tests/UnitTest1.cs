namespace CloudPractice.Tests;

public class ServiceLogicTests
{
    [Test]
    public void ListingMessage_ShouldContainListingText()
    {
        var listingName = "Test apartment";
        var message = $"New listing created: {listingName}";

        Assert.That(message, Does.Contain("Test apartment"));
        Assert.That(message, Does.Contain("New listing created"));
    }

    [Test]
    public void DisputeMessage_ShouldContainDisputeStatus()
    {
        var status = "Open";
        var message = $"Dispute status: {status}";

        Assert.That(message, Does.Contain("Open"));
        Assert.That(message, Does.Contain("Dispute status"));
    }

    [Test]
    public void QueueName_ShouldNotBeEmpty()
    {
        var queueName = "hlebhramiaka";

        Assert.That(queueName, Is.Not.Empty);
    }
}