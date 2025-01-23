document.addEventListener('DOMContentLoaded', function() {
    document.getElementById('converterForm').addEventListener('submit', async function(event) {
        event.preventDefault();
        const formData = new FormData(document.getElementById('converterForm'));

        const response = await fetch('/convert', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            const result = await response.json();
            document.getElementById('result').innerText = `Converted Temperature: ${result.convertedTemperature}`;
        } else {
            document.getElementById('result').innerText = 'Error converting temperature';
        }
    });
});