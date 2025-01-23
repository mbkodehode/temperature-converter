document.getElementById('converterForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    const temperature = document.getElementById('temperature').value;
    const conversionType = document.getElementById('conversionType').value;

    const response = await fetch('/convert', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ temperature: parseFloat(temperature), conversionType })
    });

    if (response.ok) {
        const result = await response.json();
        document.getElementById('result').innerText = `Converted Temperature: ${result.convertedTemperature}`;
    } else {
        document.getElementById('result').innerText = 'Error converting temperature';
    }
});