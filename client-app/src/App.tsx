import * as React from "react";
import {ChangeEvent, FormEvent} from "react";
import {Button, Col, Form, FormControl, FormGroup, Grid, HelpBlock, InputGroup, Row} from "react-bootstrap";
import {fetchShortenedUrl, validateUrl} from "./utils";

export type AppState = {
    sourceUrl: string;
    shortenedUrl: string;
    isFetching: boolean;
    error: string;
};

class App extends React.Component<{}, AppState> {
    constructor() {
        super();
        this.state = {
            shortenedUrl: "",
            sourceUrl   : "http://studchat.ru",
            isFetching  : false,
            error       : ""
        };
    }

    handleChange = (e: ChangeEvent<any>) => {
        const { value } = e.target;
        const error = validateUrl(value) ? "" : "This does not look like a valid URL";

        this.setState({
            [e.target.name]: value,
            shortenedUrl   : "",
            error
        });
    };

    handleSubmit = async (e: FormEvent<{}>) => {
        e.preventDefault();

        try {
            this.setState({ isFetching: true });
            const shortenedUrl = await fetchShortenedUrl(this.state.sourceUrl);
            this.setState({ shortenedUrl });
        } catch (error) {
            this.setState({ error: error || "An error occurred" });
        } finally {
            this.setState({ isFetching: false });
        }
    };

    goToShortUrl = () => window.open(this.state.shortenedUrl, "_blank");
    getValidationState = () => this.state.error || !validateUrl(this.state.sourceUrl) ? "error" : undefined;

    render() {
        const { sourceUrl, shortenedUrl, error, isFetching } = this.state;

        return (
            <Grid>
                <Row>
                    <Col sm={6} smPush={3}>
                        <Form onSubmit={this.handleSubmit}>
                            <FormGroup validationState={this.getValidationState()}>
                                <InputGroup>
                                    <FormControl
                                        type="text"
                                        value={sourceUrl}
                                        name="sourceUrl"
                                        placeholder="Enter text"
                                        onChange={this.handleChange}
                                    />
                                    <InputGroup.Button>
                                        <Button
                                            type="submit"
                                            disabled={!!error || isFetching}
                                        >
                                            Shorten!
                                        </Button>
                                    </InputGroup.Button>
                                </InputGroup>
                                {error && <HelpBlock>{error}</HelpBlock>}
                            </FormGroup>

                            <FormGroup>
                                <InputGroup>
                                    <FormControl
                                        type="text"
                                        value={shortenedUrl}
                                        readOnly
                                        id="shortenedUrl"
                                        placeholder="Here will be your short link"
                                    />
                                    <InputGroup.Button>
                                        <Button
                                            data-clipboard-target="#shortenedUrl"
                                            disabled={!shortenedUrl}
                                        >
                                            Copy
                                        </Button>
                                        <Button
                                            onClick={this.goToShortUrl}
                                            disabled={!shortenedUrl}
                                        >
                                            Go!
                                        </Button>
                                    </InputGroup.Button>
                                </InputGroup>
                            </FormGroup>
                        </Form>
                    </Col>
                </Row>
            </Grid>
        );
    }
}

export default App;
