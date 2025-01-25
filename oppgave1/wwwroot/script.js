document.getElementById('convertForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const temp = document.getElementById('temp').value;
    const fromUnits = document.getElementById('fromUnits').value;
    const toUnits = document.getElementById('toUnits').value;

    const response = await fetch('/convert', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: new URLSearchParams({
            temp: temp,
            fromUnits: fromUnits,
            toUnits: toUnits
        })
    });

    const result = await response.json();
    document.getElementById('result').innerText = `Converted Temperature: ${result.convertedTemperature}`;
});