

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/jobhub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.onclose(async () => {
    await start();
});

start();

connection.on("JobQuartz", function (message) {
    var li = document.createElement("li");
    document.getElementById("jobQuartz").appendChild(li);
    li.textContent = `${message}`;
});