var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => PrintHtml("<h1>This is the most simple App in the World</h1>"));

app.MapGet("/feature", () => PrintHtml("<h1>I'm calling \"The Most simple Api\"</h1>"));

app.Run();

static IResult PrintHtml(params string[] fragments){
    const string html = @"<html><head><title>The Most Simple App</title><style>@import url('https://fonts.googleapis.com/css?family=Muli&display=swap');@import url('https://fonts.googleapis.com/css?family=Quicksand&display=swap');
    body {{
        font-family: 'Muli', sans-serif;
        color: rgba(0, 0, 0, 0.8);
        font-weight: 400;
        line-height: 1.58;
        letter-spacing: -.003em;
        font-size: 20px;
        padding: 30px;
        }}
        h1 {{
            font-family: 'Quicksand', sans-serif;
            font-weight: 700;
            font-style: normal;
            font-size: 38px;
            line-height: 1.15;
            letter-spacing: -.02em;
            color: rgba(0, 0, 0, 0.8);
            -webkit-font-smoothing: antialiased;
            }}
        h3 {{
            font-family: 'Quicksand', sans-serif;
            font-weight: 300;
            font-style: normal;
            font-size: 15px;
            line-height: 1.15;
            letter-spacing: -.02em;
            color: rgba(0, 0, 0, 0.8);
            -webkit-font-smoothing: antialiased;
            }}
        </style></head></body><div><a href='/'>Back to home</a> - <a href='/feature'>The most rilevant Feature</a></div>{0}
        <div><h3>By @Luca Milan {1}</h3></div>
        </body></html>";   
    return Results.Content(string.Format(html, string.Join(" ",fragments), DateTime.UtcNow.ToString("u")), "text/html");
}