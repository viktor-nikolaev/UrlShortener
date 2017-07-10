export const validateUrl = (url: string) => url.match(/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/);

export const fetchShortenedUrl = async (sourceUrl: string) => {
    const response = await fetch(`/api/ShortLinks`, {
        method : "POST",
        headers: { "Content-Type": "application/json" },
        body   : JSON.stringify({ sourceUrl }),
    });

    if (!response.ok) {
        throw response.statusText;
    }

    const { shortenedUrl } = await response.json();
    return shortenedUrl as string;
};