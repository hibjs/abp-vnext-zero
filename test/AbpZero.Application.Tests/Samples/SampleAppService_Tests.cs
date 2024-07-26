using Xunit;
using Xunit.Abstractions;

namespace AbpZero.Samples;

public sealed class SampleAppService_Tests : AbpZeroApplicationTestBase
{
    private readonly ISampleAppService _sampleAppService;
    private readonly ITestOutputHelper _testOutputHelper;

    public SampleAppService_Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _sampleAppService = GetRequiredService<SampleAppService>();
    }


    [Fact]
    public void Sample_Test()
    {
        // do some test
        Assert.True(true);
    }
}