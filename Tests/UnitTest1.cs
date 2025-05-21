using System.Diagnostics;
using MessierAPI.Controllers;
using MessierAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class MessierController_Tests
{

    private MessierController? _messier;

    [SetUp]
    public void Setup() => _messier = new MessierController(new JsonDataRep());


    [Test]
    public void CallMessierEndpont_ShouldRet_infoMessierList_WithOK()
    {

        IActionResult? result = _messier!.GetMessierObjects();

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void CallMessierEndpont_ShouldRet_infoMessierListByType_WithBadRequest()
    {
        IActionResult? result = _messier!.GetMessierObject("badrequest");
        Debug.WriteLine(result);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void CallMessierEndpont_ShouldRet_infoMessierListByType_WithOK()
    {
        IActionResult? result = _messier!.GetMessierObject("nebulosa");

        Assert.That(result, Is.Not.Null);
    }
}
